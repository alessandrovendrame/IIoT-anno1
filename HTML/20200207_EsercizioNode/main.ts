import * as v from './utilities/arrayUtils';
import * as _ from 'underscore';

var vettore,array, array2,array3;

vettore = v.getList(10);
array = v.taken(vettore,5);
console.log(vettore);
console.log(array);

var daOrd = [5,7,2,6,3,4,1];

array2 = v.sortReverse(daOrd);

console.log(array2);

array3 = v.getEven(vettore);
console.log(array3);

