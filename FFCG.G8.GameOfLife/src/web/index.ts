import { GameOfLife } from "../GameOfLife";

console.log("Script loaded");

const gameOfLife = new GameOfLife(10, 10);
gameOfLife.setLivingCell(1, 4);
gameOfLife.setLivingCell(2, 3);
gameOfLife.setLivingCell(2, 4);

const content = document.getElementById("content");

let gameOfLifeBoard = "";

const drawGameOfLife = () => {
  gameOfLifeBoard =
    '<table style="margin: auto; border-spacing: 0; border: solid 2px #111"><tbody>';

  for (let row = 0; row < gameOfLife.rows; row++) {
    gameOfLifeBoard += "<tr>";

    for (let column = 0; column < gameOfLife.columns; column++) {
      const isAlive = gameOfLife.cells[row][column].isAlive;
      gameOfLifeBoard += `<td style="margin: 0; padding: 0; border: solid 1px #111; width: 22px; height: 22px; background: ${
        isAlive ? "#111" : "white"
      }"></td>`;
    }
    gameOfLifeBoard += "</tr>";
  }

  gameOfLifeBoard += "</tbody></table>";
  content.innerHTML = gameOfLifeBoard;
};

drawGameOfLife();

const onButtonClicked = () => {
  console.log("Generate button clicked");
};

document
  .getElementById("generateButton")
  .addEventListener("click", onButtonClicked);
