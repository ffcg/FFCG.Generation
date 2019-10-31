export interface IManipulateText {
  manipulate(text: string, index?: number, array?: Array<any>);
  canHandle(text: string): boolean;
}
