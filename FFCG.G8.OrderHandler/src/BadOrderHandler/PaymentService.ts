export class PaymentService {
  makePayment(items: any[], creditCardInformation: any): Promise<string> {
    return Promise.resolve("Payment done!");
  }
}
