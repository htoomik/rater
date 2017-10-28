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

@Component({
    selector: 'my-app',
    template: `
    <h1>{{title}}</h1>
    <div>
        Add another skill:
        <input [(ngModel)]="model.name">
        <input type="number" [(ngModel)]="model.rating">
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
    model = new Skill();

    addSkill()
    {
        this.skills.push(this.model);
        this.model = new Skill();
    }
}