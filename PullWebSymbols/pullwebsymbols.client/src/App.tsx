import { useState } from 'react';
import './App.css';

function App() {

    const [searchvalue, setSearchvalue] = useState<string>("");

/*   --- https://localhost:7293/Search?search=asfsaf*/

   const onClick = (searchvalue: string) => {
        fetch('Search?search=' + searchvalue);
    }

    return (
        <div>
            <input value={searchvalue} onChange={(t) => { setSearchvalue(t.target.value) }} id="search"></input>
            <button onClick={() => onClick(searchvalue)}>query</button>
        </div>
    );

}

export default App;