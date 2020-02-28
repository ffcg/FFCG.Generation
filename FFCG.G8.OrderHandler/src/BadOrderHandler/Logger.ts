export interface ILogger {
  log(message: string): string;
}

export class Logger implements ILogger {
  log(message: string): string {
    console.log(message);
    return message;
  }
}
