import { Component, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Place } from '../place/place.component';

@Component({
    selector: 'path',
    templateUrl: './path.component.html',
    styleUrls: ['./path.component.css']
})

export class PathComponent
{
    public new: Path;
    public edit: Path;
    public delete: Path;
    public items: Path[];
    public places: Place[];

    private http: Http;
    private url: string;
    private baseUrl: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string)
    {
        this.url = baseUrl;
        this.http = http;
        this.baseUrl = baseUrl + 'api/Path';
        this.new = new Path();
        this.edit = new Path();
        this.fetch_items();
        this.fetch_places();
    }

    fetch_items()
    {
        var response = this.http.get(this.baseUrl);

        response.subscribe(result =>
        {
            this.items = result.json() as Path[];
        }, error => console.error(error));
    }

    fetch_places()
    {
        var response = this.http.get(this.url + 'api/Place');

        response.subscribe(result => {
            this.places = result.json() as Place[];
        }, error => console.error(error));
    }

    add_place(item: Place)
    {
        if (this.edit.pathPlaces == null)
            this.edit.pathPlaces = new Array<PathPlace>();

        var bundle_path = new PathPlace();

        bundle_path.place = item;
        bundle_path.placeId = item.id;
        bundle_path.pathId = this.edit.id;

        this.edit.pathPlaces = this.edit.pathPlaces.concat(bundle_path);
    }

    save_path_places()
    {
    }

    delete_place(item: PathPlace)
    {
        this.edit.pathPlaces = this.edit.pathPlaces.filter(function (el) { return el.id != item.id; });
    }

    edit_item(item: Path)
    {
        this.edit = Object.assign({}, item);
    }

    delete_item(id: string)
    {
        var response = this.http.delete(this.baseUrl + '/' + this.delete.id);

        response.subscribe(data => {
            this.fetch_items();
        }, error => {
                console.log(JSON.stringify(error.json()));
            });
    }

    save_new_item(id: string)
    {
        var response = this.http.post(this.baseUrl, this.new);
        
        response.subscribe(data =>
        {
            this.fetch_items();
            this.new = new Path();
        }, error =>
        {
            console.log(JSON.stringify(error.json()));
        });
    }

    save_edit_item(id: string)
    {
        var response = this.http.put(this.baseUrl + '/' + this.edit.id, this.edit);

        response.subscribe(data =>
        {
            this.fetch_items();
            this.edit = new Path();
        }, error => {
                console.log(JSON.stringify(error.json()));
            });
    }
}

export class Path
{
    public id: number;
    public name: string;
    public info: string;
    public length: string;
    public duration: string;
    public image: string;
    public pathPlaces: PathPlace[];
}

export class PathPlace
{
    public id: number;
    public pathId: number;
    public placeId: number;
    public place: Place;
}
