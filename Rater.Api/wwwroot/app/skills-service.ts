import { Injectable } from "@angular/core";
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Skill } from './skill';
import 'rxjs/add/operator/map';

@Injectable()
export class SkillsService
{
    constructor(private http: Http) { }

    API_URL = 'api/skills';

    getAll(): Observable<Skill[]>
    {
        return this.http
            .get(this.API_URL)
            .map((response: Response) => <Skill[]>response.json());
    }

    add(skill: Skill): Observable<Skill>
    {
        return this.http
            .post(this.API_URL, skill)
            .map((response: Response) => <Skill>response.json());
    }

    delete(id: number): Observable<void>
    {
        return this.http
            .delete(this.API_URL + "/" + id)
            .map(() => null);
    }
}