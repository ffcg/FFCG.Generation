import { DivisibleByThree } from './Rules/DivisibleByThree'
import { DivisibleByFive } from './Rules/DivisibleByFive'
import { FizzBuzzAnsweringMachine } from './FizzBuzzAnsweringMachine'

const generateAnswers = (duration: number) => {
    const rules = [new DivisibleByThree(), new DivisibleByFive()]
    const machine = new FizzBuzzAnsweringMachine(rules)
    const outputContainer = document.getElementById('output')
    const oneSecond = 1000

    let answerGeneration = setInterval(() => {
        let number = 101 - duration

        if (duration <= 0){
            clearInterval(answerGeneration)
            return;
        }

        let newDiv = document.createElement('div')
        newDiv.innerHTML = machine.answer(number);
        outputContainer.appendChild(newDiv)
        duration--;
    }, 
    oneSecond)
}

generateAnswers(100)
