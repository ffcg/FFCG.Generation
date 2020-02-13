export class EmailService {
  constructor() {}

  sendEmail(email: string, content: string): Promise<string> {
    return Promise.resolve("Sent email");
  }
}
