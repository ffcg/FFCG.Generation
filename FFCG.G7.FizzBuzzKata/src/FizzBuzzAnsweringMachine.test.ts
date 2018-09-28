import { FizzBuzzAnsweringMachine } from "./FizzBuzzAnsweringMachine";
import { DivisibleByThree } from "./Rules/DivisibleByThree";
import { DivisibleByFive } from "./Rules/DivisibleByFive";
import { DivisibleBySeven } from "./Rules/DivisibleBySeven";

describe('FizzBuzzAnsweringMachine', () => {
    let fizzBuzzAnsweringMachine: FizzBuzzAnsweringMachine

    beforeEach(() => {
        const rules = [new DivisibleByThree(), new DivisibleByFive(), new DivisibleBySeven()]
        fizzBuzzAnsweringMachine = new FizzBuzzAnsweringMachine(rules)
    })

    it('should answer with "Fizz" for numbers divisible by three', () => {
        expect(fizzBuzzAnsweringMachine.answer(3)).toBe("Fizz")
    })

    it('should answer with "Buzz" for numbers divisible by five', () => {
        expect(fizzBuzzAnsweringMachine.answer(5)).toBe("Buzz")
    })

    it('should answer with "FizzBuzz" for numbers divisible by 3 and 5', () => {
        expect(fizzBuzzAnsweringMachine.answer(15)).toBe("FizzBuzz")        
    })

    it('should answer with number for numbers not divisible by 3 or 5', () => {
        expect(fizzBuzzAnsweringMachine.answer(1)).toBe("1")  
    })

    it('should answer with "Foo" for numbers divisible by seven', () => {
        let answer = fizzBuzzAnsweringMachine.answer(7)
        let expectedAnswer = "Foo"

        expect(answer).toBe(expectedAnswer)      
    })

    it('should answer with "FizzFoo" for numbers divisible by three and seven', () => {
        expect(fizzBuzzAnsweringMachine.answer(21)).toBe("FizzFoo")  
    })

    it('should answer with "FizzFoo" for numbers divisible by three and seven', () => {
        expect(fizzBuzzAnsweringMachine.answer(35)).toBe("BuzzFoo")  
    })

    it('should answer with "FizzBuzzFoo" for numbers divisible by three, five and seven', () => {
        expect(fizzBuzzAnsweringMachine.answer(105)).toBe("FizzBuzzFoo")  
    })
})