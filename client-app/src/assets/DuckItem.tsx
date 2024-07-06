import { duck } from "./demo"

interface Props{

    duck: duck
}

export default function DuckItem({duck} : Props){

return(

    <div key={duck.name}>
    <span>{duck.name}</span>
    <button onClick={() =>duck.makeSound(duck.name + 'quak')}> make sound </button>
    </div>
)

}