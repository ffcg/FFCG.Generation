import { ISettingsRepository } from "./ISaveSettings";

export class BrowserStorage implements ISettingsRepository {
  //Session storage
  //Local storage
  loadSavedStartPositions(): any[] {
    throw new Error("Method not implemented.");
  }
  loadAnimationSpeed() {
    throw new Error("Method not implemented.");
  }
  saveStartPositions(coordinates: any[]) {
    throw new Error("Method not implemented.");
  }
  saveAnimationSpeed(speed: any) {
    throw new Error("Method not implemented.");
  }
}
