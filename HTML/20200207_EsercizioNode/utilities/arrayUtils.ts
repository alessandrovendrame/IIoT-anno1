import * as _ from 'underscore';

export function getList(count : number)
{
    var list = [];

    for (let i = 0; i < count; i++) {
        
        list[i]=i+1;
        
    }

    return list;
}

export function taken(l : [] , num : number)
{
    var list = []
    for (let index = 0; index < num; index++) {
        list[index]=l[index];     
    }

    return list;
}

export function sortReverse(l:number[])
{
    var aux = _.sortBy(l,x=>x);
    var array = [];
    var j=0;

    for(let i = l.length-1; i>-1 ; i--)
    {
        array[j]=aux[i];
        j++;
    }

    return array;
}

export function getEven(l : any[])
{
    var aux=[];
    var j=0;

    for(let i=0;i<l.length;i++)
    {
        if(i%2==0)
        {
            aux[j]=l[i];
            j++;
        }
    }

    return aux;
}