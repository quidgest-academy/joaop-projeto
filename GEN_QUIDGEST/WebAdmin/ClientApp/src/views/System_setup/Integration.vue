﻿<template>
	<div id="system_setup_integration_container">
		<row>
			<q-card
				:title="systemConfigTexts.messagingSystemTitle"
				width="block"
				class="q-card--admin-default">
				<q-row-container>
					<message
						:Messaging="Messaging"
						:Metadata="Metadata"
						:model="model"
						@alert-class="forwardAlert"
					/>
				</q-row-container>
			</q-card>
		</row>

		<row class="footer-btn">
			<q-button
				variant="bold"
				:label="hardcodedTexts.saveConfiguration"
				@click="SaveIntegrationConfig" />
		</row>
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import { texts } from '@/resources/hardcodedTexts.ts';
	import { SystemConfigTexts } from '@/resources/viewResources.ts';
	import QAlert from '@/components/QAlert.vue';
	import message from './Message';
	export default {
		name: 'integration',

		components: {
			QAlert,
			message,
		},

		mixins: [reusableMixin],

		emits: ['update-model', 'alert-class'],

		props: {
			model: {
				required: true
			},
			Metadata: {
				required: true
			},
			Messaging: {
				required: true
			}
		},

		data() {
			return {
				resultMsg: "",
				statusError: false,
				alert: {
					isVisible: false,
					alertType: 'info',
					message: ''
				}
			};
		},

		computed: {
			hardcodedTexts() {
				return {
					saveConfiguration: this.Resources[texts.saveConfiguration]
				}
			},
			systemConfigTexts() {
				return new SystemConfigTexts(this)
			}
		},

		methods: {
			forwardAlert(alertData) {
				this.$emit('alert-class', alertData)
			},
			forwardUpdate() {
				this.$emit('update-model')
			},
			SaveIntegrationConfig() {
				this.model.MQueues.Journaltimeout = this.model.MQueues.Journaltimeout.toString()
				this.model.MQueues.Maxsendnumber = this.model.MQueues.Maxsendnumber.toString()
				QUtils.log("SaveIntegrationConfig - Request", QUtils.apiActionURL('Config', 'SaveIntegrationConfig'))
				QUtils.postData('Config', 'SaveIntegrationConfig', this.model, null, (data) => {
					QUtils.log("SaveIntegrationConfig - Response", data)
					this.$emit('update-model')
					if (data.Status === 'OK') {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: data.AlertType })
					}
					else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: data.AlertType })
					}
				});
			},
		}
	};
</script>
