#include <iostream>
#include <string>
using namespace std;
int main()
{
    string a, b, c;
    getline(cin, a);
    getline(cin, b);
    if (a == b) { cout << 0; return 0; } // сдвига нет, строка повторена
    int x = a.length();
    for (int z = 1; z < x; z++) {
        c = a.substr(x - z, z) + a.substr(0, x - z); // проверяем все сдвиги
        if (b == c) { cout << z; return 0; }    // пока не найдем подходящий
    }
    cout << -1; // не нашли
    return 0;
}