#ifndef eventh
#define eventh
#include <SFML/Graphics.hpp>

class Event {
public:
	Event();
	~Event();
	void handleWindow(sf::RenderWindow &);  // ikkunan osoite
};
#endif