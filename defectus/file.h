#pragma once
#include <vector>
using namespace std;

class File {
private:
	int blocksDestroyedPerRun;
	int blocksDestroyedThisRun;
	int linesCount;
	vector<int> allTimeBlocksDestroyed;
public:
	File();
	~File();
	void ReadFromFile(bool);
	void IncreaseBDestroyedCount();
	void WriteToFile();
	void PrintAll();
	int lkm;
};