import { ItemRepository } from "./ItemRepository";

describe("Item repository", () => {
  let repository: ItemRepository;

  beforeEach(() => {
    repository = new ItemRepository();
  });

  it("addItems should add items to storage", () => {
    addTwoItems();
    expect(repository.getItems().length).toBe(2);
  });

  it("removeItems should remove items from storage", () => {
    addTwoItems();
    repository.removeItems(["orange"]);
    expect(repository.getItems().length).toBe(1);
  });

  function addTwoItems() {
    const itemsToAdd = ["apple", "orange"];
    repository.addItems(itemsToAdd);
  }
});
