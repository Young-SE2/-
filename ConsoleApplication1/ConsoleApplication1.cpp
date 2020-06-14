#include <iostream>
#include <vector>     
#include <algorithm>  


struct Man
{
	int t;
	int w;
	int id;
	long long ans;
};

int main() {
	int n;
	scanf("%d", &n);
    std::vector<Man> a(n);
	for (int i = 0; i < n; i++){
		scanf("%d %d", &a[i].t, &a[i].w);
		a[i].id = i;
	}
	std::sort(a.begin(), a.end(), [](const Man &left, const Man &right) {
		return left.w < right.w; 
	});
	a[0].ans = 1LL * a[0].t * a[0].w;
	for (int i = 1; i < n; i++) {
		a[i].ans = std::max(1LL * a[i].t * a[i].w, a[i - 1].ans);
	}
	std::sort(a.begin(), a.end(), [](const Man &left, const Man &right) {
		return left.id < right.id; 
	});
	for (int i = 0; i < n; i++) {
		printf("%lld\n", a[i].ans);
	}
	return 0;
}
