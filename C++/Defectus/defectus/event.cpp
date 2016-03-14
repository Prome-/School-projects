#include "event.h"
#include "globals.h"

// Oletuskonstruktori ja -destruktori
Event::Event() {}
Event::~Event() {}

// function responsible for closing the program
void Event::handleWindow(sf::RenderWindow & window) {
	sf::Event newEvent;

	while (window.pollEvent(newEvent))
	{
		if (newEvent.type == sf::Event::Closed) { // Close the window if [x] is pressed
			window.close();
		}

		// close if esc is pressed
		if ((newEvent.type == sf::Event::KeyPressed) && (newEvent.key.code == sf::Keyboard::Escape)) {
			window.close();
		}
	}
}
