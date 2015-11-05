<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:html="http://www.w3.org/TR/REC-html40"
xmlns:myObj="urn:ms-kb">

  <xsl:template match="/NewDataSet">
    <Workbook>
      <Styles>
        <Style ss:ID="Default" ss:Name="Normal">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s16" ss:Name="Percent">
          <NumberFormat ss:Format="0%"/>
        </Style>
        <Style ss:ID="s18">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s19">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="18" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s20">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="18" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s21">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
        </Style>
        <Style ss:ID="s22">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s23">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
        <Style ss:ID="s24">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s25">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
          <Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s26">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
        </Style>
        <Style ss:ID="s27" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
        <Style ss:ID="s28">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
        </Style>
        <Style ss:ID="s29">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat/>
        </Style>
        <Style ss:ID="s30">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s31">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s32">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <Interior/>
        </Style>
        <Style ss:ID="s33" ss:Parent="s16">
          <Alignment ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
        <Style ss:ID="s34">
          <Alignment ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s35">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
        <Style ss:ID="s166">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s318">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="12" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s411">
          <Alignment ss:Vertical="Top"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="18" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s412">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s413">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s414">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s416">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
      </Styles>
      <Worksheet ss:Name="tong hop truong bo phan">

        <Table ss:ExpandedColumnCount="14"  x:FullColumns="1"
         x:FullRows="1" ss:StyleID="s18" ss:DefaultRowHeight="14.25">
          <Column ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="20.25"/>
          <Column ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="57.75"/>
          <Column ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="33"/>
          <Column ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="37.5" ss:Span="1"/>
          <Column ss:Index="6" ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="33.75"/>
          <Column ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="28.5" ss:Span="1"/>
          <Column ss:Index="9" ss:StyleID="s35" ss:AutoFitWidth="0" ss:Width="31.5"/>
          <Column ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="97.5"/>
          <Column ss:StyleID="s412" ss:AutoFitWidth="0" ss:Width="102"/>
          <Column ss:StyleID="s24" ss:AutoFitWidth="0" ss:Width="89.25"/>
          <Column ss:StyleID="s24" ss:AutoFitWidth="0" ss:Width="153"/>
          <Column ss:StyleID="s18" ss:AutoFitWidth="0" ss:Width="78.75"/>
          <Row ss:Height="23.25">
            <Cell ss:Index="2" ss:StyleID="s19">
              <Data ss:Type="String">BẢNG TỔNG HỢP XẾP LOẠI TRƯỞNG BỘ PHẬN 6 THÁNG</Data>
            </Cell>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s411"/>
            <Cell ss:StyleID="s19"/>
            <Cell ss:StyleID="s20"/>
            <Cell ss:StyleID="s20"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s21"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:StyleID="s23"/>
            <Cell ss:StyleID="s22"/>
            <Cell ss:Index="14" ss:StyleID="s22"/>
          </Row>
          <Row ss:Height="15.75" ss:StyleID="s22">
            <Cell ss:MergeDown="2" ss:StyleID="s414">
              <Data ss:Type="String">STT</Data>

            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s414">
              <Data ss:Type="String">Họ tên</Data>

            </Cell>
            <Cell ss:MergeAcross="6" ss:StyleID="s318">

            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s414">
              <Data ss:Type="String">CEO ĐÁNH GIÁ</Data>

            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="s318">
              <Data ss:Type="String">GHI CHÚ</Data>

            </Cell>
          </Row>
          <Row ss:StyleID="s413">
            <Cell ss:Index="3" ss:MergeAcross="1" ss:StyleID="s414">
              <Data ss:Type="String">HOÀN THÀNH CÔNG VIỆC</Data>

            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="s414">
              <Data ss:Type="String">THÁI ĐỘ VÀ KỶ LUẬT LÀM VIỆC (20)</Data>

            </Cell>
            <Cell ss:MergeDown="1" ss:StyleID="s416">
              <Data ss:Type="String">TỔNG ĐIỂM</Data>

            </Cell>
            <Cell ss:Index="11" ss:MergeDown="1" ss:StyleID="s414">
              <Data ss:Type="String">ĐIỂM MẠNH CỦA CÁ NHÂN</Data>

            </Cell>
            <Cell ss:MergeDown="1" ss:StyleID="s414">
              <Data ss:Type="String">ĐIỂM YẾU CỦA CÁ NHÂN - KẾ HOẠCH SỬA ĐỔI</Data>

            </Cell>
            <Cell ss:MergeDown="1" ss:StyleID="s414">
              <Data ss:Type="String">KẾ HOẠCH 6 THÁNG CUỐI NĂM 2013</Data>

            </Cell>
            <Cell ss:MergeDown="1" ss:StyleID="s414">
              <Data ss:Type="String">ĐỀ XUẤT</Data>

            </Cell>
          </Row>
          <Row ss:Height="89.25" ss:StyleID="s413">
            <Cell ss:Index="3" ss:StyleID="s25">
              <Data ss:Type="String">Xếp loại bộ phận</Data>

            </Cell>
            <Cell ss:StyleID="s25">
              <Data ss:Type="String">Điểm cho Trưởng bộ phận</Data>

            </Cell>
            <Cell ss:StyleID="s25">
              <Data ss:Type="String">Đào tạo phát triển nhân sự</Data>

            </Cell>
            <Cell ss:StyleID="s25">
              <Data ss:Type="String">Lãnh đạo, dẫn dắt, truyền cảm hứng</Data>

            </Cell>
            <Cell ss:StyleID="s25">
              <Data ss:Type="String">Chuyên môn làm việc</Data>

            </Cell>
            <Cell ss:StyleID="s25">
              <Data ss:Type="String">Thái độ kỷ luật và văn hóa công ty</Data>

            </Cell>
          </Row>
          <xsl:apply-templates select="Table"></xsl:apply-templates>

        </Table>

      </Worksheet>
    </Workbook>
  </xsl:template>

  <xsl:template match="Table">

    <Row ss:AutoFitHeight="0" ss:Height="172.5">
      <Cell ss:StyleID="s26">
        <Data ss:Type="Number">
          <xsl:value-of select="STT"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s26">
        <Data ss:Type="String">
          <xsl:value-of select="Ten"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s27">
        <Data ss:Type="String">
          <xsl:value-of select="XepLoai"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s27">
        <Data ss:Type="Number">
          <xsl:value-of select="Diem"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s27">
        <Data ss:Type="Number">
          <xsl:value-of select="DiemTDKL1"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s27">
        <Data ss:Type="Number">
          <xsl:value-of select="DiemTDKL2"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s27">
        <Data ss:Type="Number">
          <xsl:value-of select="DiemTDKL3"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s27">
        <Data ss:Type="Number">
          <xsl:value-of select="DiemTDKL4"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s27">
        <Data ss:Type="Number">
          <xsl:value-of select="TongDiem"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s318"/>
      <Cell ss:StyleID="s30">
        <Data ss:Type="String">
          <xsl:value-of select="DiemManh"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s30">
        <Data ss:Type="String">
          <xsl:value-of select="DiemYeu"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s28">
        <Data ss:Type="String">
          <xsl:value-of select="KeHoach6ThangToi"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s26">
        <Data ss:Type="String">
          <xsl:value-of select="DeXuat"/>
        </Data>
      </Cell>
    </Row>


  </xsl:template>

</xsl:stylesheet>


