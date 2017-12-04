using System;
using Xunit;

namespace FFCG.G6.Dicer.Tests
{
    public class GameTests
    {
        [Fact]
        public void Start_should_roll_initial_roll_and_start_game()
        {
            var game = new Game(new FakeDice(3));
            game.Start();
            Assert.Equal(3, game.LatestRoll);
            Assert.True(game.IsPlaying);
        }

        [Fact]
        public void Guessing_higher_and_correct_should_give_one_point_roll_again_and_still_be_playing()
        {
            var game = new Game(new FakeDice(3, 6));
            game.Start();

            game.GuessHigher();

            Assert.Equal(1, game.Score);
            Assert.True(game.IsPlaying);
        }

        [Fact]
        public void Guessing_lower_and_correct_should_give_one_point_roll_again_and_still_be_playing()
        {
            var game = new Game(new FakeDice(3, 1));
            game.Start();

            game.GuessLower();

            Assert.Equal(1, game.Score);
            Assert.True(game.IsPlaying);
        }

        [Fact]
        public void Guessing_higher_but_roll_was_same_as_last_should_give_no_points_but_still_be_playing()
        {
            var game = new Game(new FakeDice(3, 3));
            game.Start();

            game.GuessHigher();

            Assert.Equal(0, game.Score);
            Assert.True(game.IsPlaying);
        }

        [Fact]
        public void Guessing_lower_but_roll_was_same_as_last_should_give_no_points_but_still_be_playing()
        {
            var game = new Game(new FakeDice(3, 3));
            game.Start();

            game.GuessLower();

            Assert.Equal(0, game.Score);
            Assert.True(game.IsPlaying);
        }

        [Fact]
        public void Guessing_higher_but_incorrect_should_give_no_points_and_game_over()
        {
            var game = new Game(new FakeDice(3, 1));
            game.Start();

            game.GuessHigher();

            Assert.Equal(0, game.Score);
            Assert.False(game.IsPlaying);
        }

        [Fact]
        public void Guessing_lower_but_incorrect_should_give_no_points_and_game_over()
        {
            var game = new Game(new FakeDice(3, 6));
            game.Start();

            game.GuessLower();

            Assert.Equal(0, game.Score);
            Assert.False(game.IsPlaying);
        }
    }
}
