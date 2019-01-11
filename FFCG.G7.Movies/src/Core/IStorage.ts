export interface IStorage<T> {
    load(id: any): T
    store(obj: any): void
    delete(obj: any): void
    all(): Array<T>
}