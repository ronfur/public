import { Component, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'place',
    templateUrl: './place.component.html',
    styleUrls: ['./place.component.css']
})

export class PlaceComponent
{
    public new: Place;
    public edit: Place;
    public delete: Place;
    public items: Place[];

    private http: Http;
    private baseUrl: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string)
    {
        this.http = http;
        this.baseUrl = baseUrl + 'api/Place';
        this.new = new Place();
        this.edit = new Place();
        this.fetch_items();
    }

    fetch_items()
    {
        var response = this.http.get(this.baseUrl);

        response.subscribe(result =>
        {
            this.items = result.json() as Place[];
        }, error => console.error(error));
    }

    edit_item(item: Place)
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
            this.new = new Place();
        }, error =>
        {
            console.log(JSON.stringify(error.json()));
        });
    }

    save_edit_item(id: string)
    {
        var response = this.http.put(this.baseUrl + '/' + this.edit.id, this.edit);

        response.subscribe(data => {
            this.fetch_items();
            this.edit = new Place();
        }, error => {
                console.log(JSON.stringify(error.json()));
            });
    }
}

export class Place
{
    id: number;
    name: string;
    info: string;
    image: string;
    radius: number;
}