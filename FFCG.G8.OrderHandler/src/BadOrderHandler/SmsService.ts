import { INotifyCustomerAboutOrder } from "./OrderNotifications/INotifyCustomerAboutOrder";
import { Customer } from "./CustomerRepository";

export class SmsService implements INotifyCustomerAboutOrder {
  notify(customer: Customer, order: any) {
    return Promise.resolve("OK");
  }

  sendSms(
    phoneNumber: string,
    content: string,
    shippingInformation: any
  ): Promise<string> {
    return Promise.resolve("Sent SMS");
  }
}
