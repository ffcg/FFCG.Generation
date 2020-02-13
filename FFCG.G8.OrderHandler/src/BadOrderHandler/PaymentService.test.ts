import { PaymentService } from "./PaymentService";

describe("Payment Service", () => {
  let paymentService: PaymentService;

  beforeEach(() => {
    paymentService = new PaymentService();
  });

  it("makePayment should successfully make payment", done => {
    const items = [];
    const creditCardInformation = {};

    paymentService.makePayment(items, creditCardInformation).then(result => {
      expect(result).toBe("Payment done!");
      done();
    });
  });
});
