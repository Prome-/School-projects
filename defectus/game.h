#ifndef gameh
#define gameh
#include <SFML/Graphics.hpp>

class Game {
private:
	int gameStatus;
public:
	Game();
	~Game();
	int getStatus();
	void setStatus(int);	// Asettaa gamestatuksen: [0|1]
};

#endif