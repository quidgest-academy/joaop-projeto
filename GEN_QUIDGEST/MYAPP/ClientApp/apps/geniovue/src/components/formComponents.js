import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormFAgent', defineAsyncComponent(() => import('@/views/forms/FormFAgent/QFormFAgent.vue')))
		app.component('QFormFClub', defineAsyncComponent(() => import('@/views/forms/FormFClub/QFormFClub.vue')))
		app.component('QFormFCntrct', defineAsyncComponent(() => import('@/views/forms/FormFCntrct/QFormFCntrct.vue')))
		app.component('QFormFCntry', defineAsyncComponent(() => import('@/views/forms/FormFCntry/QFormFCntry.vue')))
		app.component('QFormFPlayer', defineAsyncComponent(() => import('@/views/forms/FormFPlayer/QFormFPlayer.vue')))
	}
}
