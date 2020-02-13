export class Customer {
  id: string;
  name: string;
  email: string;
  phoneNumber: string;
  deviceId: string;
}

export class CustomerRepository {
  get(id: string): Promise<Customer> {
    var fakeCustomer = new Customer();
    fakeCustomer.id = id;
    fakeCustomer.name = "Erik";
    fakeCustomer.email = "erik@forefront.se";
    fakeCustomer.phoneNumber = "0701020345";
    fakeCustomer.deviceId = "deviceId";
    return Promise.resolve(fakeCustomer);
  }
}
