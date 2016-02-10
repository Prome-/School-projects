
#include "file.h"
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

File::File() {
	blocksDestroyedThisRun = 0;
	linesCount = 0;
}

File::~File() {
}

//Lukee tiedostosta kaikki rivit ja asettaa ne vektoriin. 
void File::ReadFromFile(bool atEnd) {

	string line;
	ifstream myfile("blocksdestroyed.txt");								//streamin alustus
	if (myfile.is_open()){												//jos tiedosto aukesi ok
		while (getline(myfile, line)){
			blocksDestroyedPerRun = atoi(line.c_str());					//langan pää myöhemmin implementoitavalle toiminnalle
			if (atEnd) {												//tutkitaan onko ohjelman graafisen osuuden suoritus lakannut
				allTimeBlocksDestroyed.push_back(blocksDestroyedPerRun);//otetaan tiedostosta kaikki rivit vektoriin
				linesCount++;
			}
			else {
				linesCount++;
			}
		} 
		myfile.close();													//sulje tiedosto
	} else { cout << "Unable to open file"; }							//jos tiedosto ei auennut oikein
	//cout << lkm << endl;
}

void File::IncreaseBDestroyedCount() {									//pitää kirjaa montako palikkaa on tuhottu ohjelman ajon aikana, kutsutaan aina luodin ja palikan törmäyksen yhteydessä
	blocksDestroyedThisRun +=1;
}

void File::WriteToFile() {												//hoitaa kierroksella tuhottujen palikoiden yhteismäärän kirjoittamisen tiedostoon
	ofstream myfile;
	myfile.open("blocksdestroyed.txt", std::ios_base::app);
	if (myfile.is_open())
	{
		myfile << blocksDestroyedThisRun <<"\n";						
		myfile.close();
	}
	else cout << "Unable to open file";
}

void File::PrintAll() {													//kutsuu omaa jäsenfunktiotaan read from file, tulostaa vektorista kaikkien ohjelman ajokertojen tuhotut palikat, ja ilmoittaa yhteenlasketun määrän siihen astisista kierroksista
	this->ReadFromFile(true);
	int j = 1;
	int last = 0;
	bool firstRun = true;
	bool lastRun = false;

	for (std::vector<int>::iterator i = allTimeBlocksDestroyed.begin(); i != allTimeBlocksDestroyed.end(); ++i) {		//alustetaan vektori-iteraattori toteutusvälillä vektorin alkupäästä sen loppuun
		if (j == linesCount-1) { lastRun = true; }																		//tutkitaanko käsitelläänkö tiedoston viimeistä riviä
		
		if (!firstRun && !lastRun) {																					//jos ei ensimmäinen eikä viimeinen rivi
			cout << endl << endl << "Ohjelman suorituskerralla " << j << " palikoita tuhottiin: " << *i << " kappaletta. Yhteensa " << last + *i << " kappaletta.";
			last = *i;
		}
		else if (!firstRun && lastRun) {																				//jos viimeinen kierros
			cout << endl << endl << "Ohjelman suorituskerralla " << j << " palikoita tuhottiin: " << *i << " kappaletta. Yhteensa " << last + blocksDestroyedThisRun << " kappaletta.";
		}
		else {																											//jos ensimmäinen kierros
			cout << endl << endl << "Ohjelman suorituskerralla " << j << " palikoita tuhottiin: " << *i << " kappaletta.";
			firstRun = false;
			last = *i;
		}
			
		j++;
	}
	cout << endl << endl;
}