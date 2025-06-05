<template>
	<row>
		<q-card
			id="system_setup_reporting_container"
			width="block"
			class="q-card--admin-default"
			:title="systemConfigTexts.reportsTitle">
			<q-row-container>
				<row>
					<q-card
						class="q-card--admin-border-less q-card--admin-compact"
						width="block">
						<q-row-container class="control-row-group">
							<div class="q-help__info-banner">
								<div class="q-help__info-banner-header">
									<q-icon icon="information-outline" />
									<h5>{{ systemConfigTexts.reportsPathLabel }}</h5>
								</div>
								<div class="q-help__info-banner-body">
									<span style="white-space: pre-line">
										{{ systemConfigTexts.reportsPathInfo }}<br>
										<b>{{ systemConfigTexts.crystalReportsLabel }}</b><br>
										{{ systemConfigTexts.crystalReportsInfo }}<br>
										<b>{{ systemConfigTexts.reportingServicesLabel }}</b><br>
										{{ systemConfigTexts.reportingServicesInfo }}<br>
									</span>
								</div>
							</div>
							<q-control-wrapper class="control-row-group">
								<q-text-field
									v-model="model.pathReports"
									:label="systemConfigTexts.reportsPathLabel"
									size="xlarge" />
							</q-control-wrapper>
						</q-row-container>
					</q-card>
				</row>
				<row>
					<q-card
						class="q-card--admin-border-top q-card--admin-compact"
						:title="systemConfigTexts.sqlServerReportingServicesTitle"
						width="block">
						<q-row-container>
							<q-text-field
								v-model="model.ssrsServer"
								:label="hardcodedTexts.url"
								size="xlarge" />
							<q-text-field
								v-model="model.ssrsServerPath"
								:label="hardcodedTexts.path"
								size="xlarge" />
							<q-checkbox
								v-model="model.isLocalReports"
								:label="systemConfigTexts.isLocalReportsLabel" />
							<q-text-field
								v-model="model.ssrsServerDomain"
								:label="hardcodedTexts.domain"
								size="xlarge" />
							<q-text-field
								v-model="model.ssrsServerUsername"
								:label="hardcodedTexts.username"
								size="xlarge" />
							<password-input
								v-model="model.ssrsServerPassword"
								:label="hardcodedTexts.password"
								:showFiller="model.hasSsrsServerPassword"
								size="xlarge">
							</password-input>
						</q-row-container>
					</q-card>
				</row>
			</q-row-container>
		</q-card>
	</row>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import { SystemConfigTexts } from '@/resources/viewResources.ts';
	import { texts } from '@/resources/hardcodedTexts.ts';

	export default {
		name: 'reports',

		props: {
			model: {
				required: true
			},
		},
		mixins: [reusableMixin],

		computed: {
			systemConfigTexts() {
				return new SystemConfigTexts(this)
			},
			hardcodedTexts() {
				return {
					domain: this.Resources[texts.domain],
					username: this.Resources[texts.username],
					url: this.Resources[texts.url],
					path: this.Resources[texts.path],
					password: this.Resources[texts.password]
				}
			}
		}
	};
</script>
