import { CustomerRepository } from "./CustomerRepository";

describe("Customer repository", () => {
  let customerRepository: CustomerRepository;

  beforeEach(() => {
    customerRepository = new CustomerRepository();
  });

  it("get should return expected customer", done => {
    const customerId = "customerId";

    customerRepository.get(customerId).then(customer => {
      expect(customer.id).toBe(customerId);
      done();
    });
  });
});
