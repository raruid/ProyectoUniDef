
import { Component,  Injector } from '@angular/core';
import {EventosServiceProxy, EventoDto, AuthenticateResultModel, EventoDtoPagedResultDto, EventoDatosPerfilDto, UserServiceProxy, UserDatosPerfilDto, AsistentesServiceProxy, AsistenteDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
//import { CreateEventoDialogComponent } from '../user-profile/create-evento/create-evento-dialog.component';
import { EditEventoDialogComponent } from './edit-evento/edit-evento-dialog.component';
import { ActivatedRoute } from '@angular/router';

class PagedRolesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-eventos',
    templateUrl: './eventos.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class EventosComponent extends PagedListingComponentBase<EventoDatosPerfilDto> {

    evento: EventoDatosPerfilDto;
    usuarioLogado: UserDatosPerfilDto;
    asistente: AsistenteDto;
    filterText = '';
    _id = '';
    constructor(
        injector: Injector,
        private _eventoService: EventosServiceProxy,
        private _userService: UserServiceProxy,
        private _asistenteService: AsistentesServiceProxy,
        private _route: ActivatedRoute
    ) {
        super(injector);
        this._id = this._route.snapshot.paramMap.get('id');
    }

    list(
        request: PagedRolesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filterText;

        this._eventoService
            .getEventoPorId(parseInt(this._id))
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.evento = result;
            });

        this._userService
            .getDatosUsuarioLogado()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.usuarioLogado = result;
        });

        this._asistenteService
            .esAsistente(parseInt(this._id))
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.asistente = result;
        })    
    //ngOnInit() {
    //    this._eventoService.getAll('', 0, 20)
    //        .subscribe(result =>
    //        this.eventos = result.items);
    }

    asistirEvento(id: number) {
        this._asistenteService
            .asistirEvento(id)
            .subscribe(result  => {
                this.refresh();
                abp.notify.success(this.l('Estas asistiendo a este evento'));
              });
    }
    
    dejarDeAsistir(id: number){
        this._asistenteService
            .dejarDeAsistir(id)
            .subscribe(result  => {
                this.refresh();
                abp.notify.success(this.l('Te has desapuntado del evento'));
              });
    }    


    delete(entity: EventoDatosPerfilDto): void {
        throw new Error("Method not implemented.");
    }


}
