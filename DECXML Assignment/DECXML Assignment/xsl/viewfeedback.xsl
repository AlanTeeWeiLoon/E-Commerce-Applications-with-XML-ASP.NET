<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<link rel="stylesheet"
					  type="text/css"
					  href="css/viewrecordcss.css"/>
			</head>
			<body>
				<div>
					<table>
						<tr>
							<th>Feedback ID</th>
							<th>Name</th>
							<th>Email</th>
							<th>Subject</th>
							<th>Message</th>
							<th>Date</th>
							<th></th>
						</tr>
						<xsl:for-each select="Feedbacks/Feedback">
							<tr>
								<td>
									<xsl:value-of select="feedback_id"/>
								</td>
								<td>
									<xsl:value-of select="name"/>
								</td>
								<td>
									<xsl:value-of select="email"/>
								</td>
								<td>
									<xsl:value-of select="subject"/>
								</td>
								<td>
									<xsl:value-of select="message"/>
								</td>
								<td>
									<xsl:value-of select="date"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>