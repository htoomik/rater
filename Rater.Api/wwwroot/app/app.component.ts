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
    templateUrl: './template.html',
    styleUrls: [ './styles.css' ]
})

export class AppComponent
{
    skills = SKILLS;
    validRatings = VALID_RATINGS;
    model = new Skill();

    addSkill()
    {
        this.skills.push(this.model);
        this.model = new Skill();
    }

    removeSkill(id: number)
    {
        console.log("removing skill " + id);
    }
}