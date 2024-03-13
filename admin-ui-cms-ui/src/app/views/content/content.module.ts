import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';


import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';

import { ContentRoutingModule } from './content-routing.module';
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import { PanelModule } from 'primeng/panel';
import { BlockUIModule } from 'primeng/blockui';
import { BadgeModule } from 'primeng/badge';
import { CheckboxModule } from 'primeng/checkbox';
import { KeyFilterModule } from 'primeng/keyfilter';
import { BlogSharedModule } from 'src/app/shared/modules/myblog-shared.module';
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
import { PostCategoryComponent } from './post-categories/post-category.component';
import { PostCategoryDetailComponent } from './post-categories/post-category-detail.component';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
@NgModule({
  imports: [
    ContentRoutingModule,
    IconModule,
    CommonModule,
    ReactiveFormsModule,
    ChartjsModule,
    ProgressSpinnerModule,
    PanelModule,
    BlockUIModule,
    PaginatorModule,
    BadgeModule,
    CheckboxModule,
    KeyFilterModule,
    BlogSharedModule,
    TableModule,
    InputTextModule,
    ButtonModule
  ],
  declarations: [PostCategoryComponent, PostCategoryDetailComponent]
})
export class ContentModule {
}
