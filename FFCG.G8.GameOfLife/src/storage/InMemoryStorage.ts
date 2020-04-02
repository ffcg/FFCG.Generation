import { ISettingsRepository } from "./ISaveSettings";

export class InMemoryStorage implements ISettingsRepository {
  startPositions = [];
  loadSavedStartPositions(): any[] {
    return this.startPositions;
  }
  loadAnimationSpeed() {
    throw new Error("Method not implemented.");
  }
  saveStartPositions(coordinates: any[]) {
    this.startPositions = coordinates;
  }
  saveAnimationSpeed(speed: any) {
    throw new Error("Method not implemented.");
  }
}
