import { Component } from '@angular/core';
import { Skill } from './skill';

const SKILLS : Skill[] =
[
    { id: 1, name: ".NET", rating: 5 },
    { id: 2, name: "SQL", rating: 4 },
    { id: 3, name: "JavaScript", rating: 2 },
    { id: 4, name: "TypeScript", rating: 1 },
    { id: 5, name: "Angular", rating: 1 },
]

const VALID_RATINGS : number[] = [ 0, 1, 2, 3, 4, 5 ];

@Component({
    selector: 'my-app',
    template: `
    <h1>{{title}}</h1>
    <div>
        Add another skill:
        <input [(ngModel)]="model.name">
        <div *ngFor="let r of validRatings">
            <input type="radio" value="{{r}}" [(ngModel)]="model.rating">
            <label>{{r}}</label>
        </div>
        <button (click)="addSkill()">Add</button>
    </div>
    <ul>
        <li *ngFor="let skill of skills">
            <span>{{skill.name}}</span>
            <span>{{skill.rating}}</span>
        </li>
    </ul>
    `,
})

export class AppComponent
{
    title = 'Skills';
    skills = SKILLS;
    validRatings = VALID_RATINGS;
    model = new Skill();

    addSkill()
    {
        this.skills.push(this.model);
        this.model = new Skill();
    }
}