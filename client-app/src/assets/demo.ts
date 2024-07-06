export interface duck {


    name : string
    numlegs : number
    makeSound: (sound : string ) => void;

}


const duck1 : duck = {
    name: 'arebb',
    numlegs: 0,
    makeSound:  (sound: string) => console.log(sound)
    
}

duck1.makeSound('sda');
duck1.name = 'areeb';
export const ducks = [duck1]