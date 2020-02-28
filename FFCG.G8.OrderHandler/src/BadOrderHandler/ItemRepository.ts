export interface IItemRepository {
  addItems(items: any[]);
  removeItems(items: any[]);
  getItems(): any[];
}

export class ItemRepository implements IItemRepository {
  items: any[];

  constructor() {
    this.items = [];
  }

  addItems(items: any[]) {
    this.items = [...this.items, ...items];
  }

  removeItems(items: any[]) {
    for (var i = 0; i < items.length; i++)
      this.items = this.items.filter(x => x !== items[i]);
  }

  getItems(): any[] {
    return this.items;
  }
}
