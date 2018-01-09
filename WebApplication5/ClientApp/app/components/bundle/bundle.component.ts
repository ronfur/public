import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Path } from '../path/path.component';

@Component({
    selector: 'bundle',
    templateUrl: './bundle.component.html',
    styleUrls: ['./bundle.component.css']
})

export class BundleComponent
{
    public new: Bundle;
    public edit: Bundle;
    public delete: Bundle;
    public items: Bundle[];
    public paths: Path[];

    private http: Http;
    private baseUrl: string;
    private url: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string)
    {
        this.url = baseUrl;
        this.http = http;
        this.baseUrl = baseUrl + 'api/Bundle';
        this.new = new Bundle();
        this.edit = new Bundle();
        this.fetch_items();
        this.fetch_paths();
    }

    fetch_items()
    {
        var response = this.http.get(this.baseUrl);

        response.subscribe(result =>
        {
            this.items = result.json() as Bundle[];
        }, error => console.error(error));
    }

    fetch_paths()
    {
        var response = this.http.get(this.url + 'api/Path');

        response.subscribe(result => {
            this.paths = result.json() as Path[];
        }, error => console.error(error));
    }

    add_path(item: Path)
    {
        if (this.edit.bundlePaths == null)
            this.edit.bundlePaths = new Array<BundlePath>();

        var bundle_path = new BundlePath();

        bundle_path.path = item;
        bundle_path.pathId = item.id;
        bundle_path.bundleId = this.edit.id;

        this.edit.bundlePaths = this.edit.bundlePaths.concat(bundle_path);
    }

    delete_path(item: BundlePath)
    {
        this.edit.bundlePaths = this.edit.bundlePaths.filter(function (el) { return el.id != item.id; }); 
    }

    save_bundle_paths()
    {
    }

    edit_item(item: Bundle)
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
            this.new = new Bundle();
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
            this.edit = new Bundle();
        }, error => {
                console.log(JSON.stringify(error.json()));
            });
    }
}

export class Bundle
{
    public id: number;
    public name: string;
    public image: string;
    public info: string;
    public bundlePaths: BundlePath[];
}

export class BundlePath
{
    public id: number;
    public bundleId: number;
    public pathId: number;
    public path: Path;
}
