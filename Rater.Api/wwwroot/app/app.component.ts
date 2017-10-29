import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Skill } from './skill';
import { SkillsService } from './skills-service';

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
    styleUrls: [ './styles.css' ],
    providers: [ SkillsService ]
})

export class AppComponent implements OnInit
{
    service: SkillsService;
    skills: Skill[];
    validRatings = VALID_RATINGS;
    model = new Skill();

    constructor(private skillsService: SkillsService)
    {
        this.skillsService = skillsService;
    }

    getSkills()
    {
        this.skillsService.getAll().subscribe(
            resultArray => this.skills = resultArray,
            error => console.log(error)
        );
    }

    ngOnInit()
    {
        this.getSkills();
    }

    addSkill()
    {
        this.skillsService
            .add(this.model)
            .subscribe(value => this.skills.push(value));
        this.model = new Skill();
    }

    removeSkill(id: number)
    {
        this.skillsService
            .delete(id)
            .map(() => this.getSkills())
            .subscribe(
                () => null,
                error => console.log(error));
    }
}