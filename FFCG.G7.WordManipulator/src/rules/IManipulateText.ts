export interface IManipulateText {
   manipulate(text: string, index?: number, array?: Array<any>): string
   canHandle(text: string): boolean 
}
