#include "game.h"	
#include "globals.h"

Game::Game() 
{
	cout << "Game constructor!" << endl;
	this->gameStatus = 0;
}

Game::~Game() { cout << "Game destructor!" << endl; }

int Game::getStatus() 
{
	
	return this->gameStatus;
}

void Game::setStatus(int gs) {
	this->gameStatus = gs;
}