import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'summary'
})
export class SummaryPipe implements PipeTransform{
    transform(value: any, limit?: number) {
        if(!value) return null;
        let _limit = limit ? (limit) : limit = 10
        return value.substr(0,_limit)+ '...';
    }
    
}