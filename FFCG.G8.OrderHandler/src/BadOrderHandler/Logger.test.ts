import { Logger } from "./Logger";

describe("Logger", () => {
  it("log should log message", () => {
    const logger = new Logger();
    const loggedMessage = logger.log("The message");
    expect(loggedMessage).toBe("The message");
  });
});
