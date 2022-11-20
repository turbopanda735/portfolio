// everything goes in app?

const App = () => {
    const [data, setData] = useState({ data: [] });

    const updateClick = async () => {

        const response = await fetch('https://joelkozek.com/api/todo/1')
        const result = await response.json()

        console.log('and the result is: ', JSON.stringify(result, null, 3))
    }
    console.log(data);

    return (
        <div>
            <button onClick={updateClick}> update </button>
            {data.data.map(todo => {
                return (
                    <div key={todo.Id}>
                        <p>{todo.IsComplete}</p>
                    </div>
                );
            })}
        </div>
    );
};

ReactDOM.render(<App/>, document.getElementById('update-button-root'));
