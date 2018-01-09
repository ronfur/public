import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { BundleComponent } from './components/bundle/bundle.component';
import { PlaceComponent } from './components/place/place.component';
import { PathComponent } from './components/path/path.component';
/*
import { ModalComponent } from './components/modal/modal.component';
import { ModalService } from './components/modal/modal.service';*/

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        PathComponent,
        PlaceComponent,
        BundleComponent//,
       // ModalComponent
    ],
    //providers: [ModalService],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'bundle', pathMatch: 'full' },
            { path: 'bundle', component: BundleComponent },
            { path: 'path', component: PathComponent },
            { path: 'place', component: PlaceComponent },
            { path: '**', redirectTo: 'bundle' }
        ])
    ]
})
export class AppModuleShared {
}
