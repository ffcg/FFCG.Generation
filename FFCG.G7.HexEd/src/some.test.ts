import { TestClass } from "./testfile";

describe('Some test', () => {
    it('should say hi', () => {
        expect(new TestClass().sayHi()).toBe('Hi!')
    })
})