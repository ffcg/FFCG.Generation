import { Customer } from "../CustomerRepository";

export interface INotifyCustomerAboutOrder {
  notify(customer: Customer, order: any): Promise<any>;
}
