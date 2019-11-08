import { readFileSync } from "fs";

export const readInputFile = readFileSync("input.txt")
  .toString()
  .split("\n");
