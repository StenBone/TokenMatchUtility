<?xml version="1.0"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>
          <xsl:value-of select="Response/Result/KittenInfo/Name"/> Adopted by the <xsl:value-of select="Response/Result/Adopter/Name"/>
        </h2>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>