export interface ISettingsRepository {
  saveStartPositions(coordinates: Array<any>);
  saveAnimationSpeed(speed: any);
  loadSavedStartPositions(): Array<any>;
  loadAnimationSpeed(): any;
}
