#ifndef characterh
#define characterh
#include <SFML/Graphics.hpp>
#include "crosshair.h"


class Character : public sf::RectangleShape {

public:
	Character();
	~Character();
	Character(std::string, int, sf::Texture *, sf::Texture *);
	Crosshair* getCrosshair();
	int getShotCooldown();
	void addCrosshair(Crosshair *, sf::Texture *);
	void setShotCooldown();
	int direction;
private:
	Crosshair xhair;
	int shotCooldown;
	int jumpCooldown;
};

#endif